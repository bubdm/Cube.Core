# --------------------------------------------------------------------------- #
#
# Copyright (c) 2010 CubeSoft, Inc.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#  http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
# --------------------------------------------------------------------------- #
require 'rake'
require 'rake/clean'

# --------------------------------------------------------------------------- #
# configuration
# --------------------------------------------------------------------------- #
PROJECT   = "Cube.Core"
BRANCHES  = ["master", "netstandard2.0", "net35"]
PLATFORMS = ["Any CPU"]
PACKAGES  = ["Libraries/#{PROJECT}.nuspec"]
TESTS     = ["Tests/#{PROJECT}.Tests.csproj"]

# --------------------------------------------------------------------------- #
# clean
# --------------------------------------------------------------------------- #
CLEAN.include(["bin", "obj"].map{ |e| "**/#{e}" })
CLEAN.include("*.nupkg")
CLOBBER.include("../packages/cube.*")

# --------------------------------------------------------------------------- #
# default
# --------------------------------------------------------------------------- #
desc "Clean, build, test, and create NuGet packages."
task :default => [:clean, :build_all, :test_all, :pack]

# --------------------------------------------------------------------------- #
# pack
# --------------------------------------------------------------------------- #
desc "Create NuGet packages in the net35 branch."
task :pack do
    pack = %(nuget pack -Properties "Configuration=Release;Platform=AnyCPU")
    checkout("net35") { PACKAGES.each { |e| cmd("#{pack} #{e}") }}
end

# --------------------------------------------------------------------------- #
# restore
# --------------------------------------------------------------------------- #
desc "Resote NuGet packages in the current branch."
task :restore do
    cmd("dotnet restore #{PROJECT}.sln")
end

# --------------------------------------------------------------------------- #
# build
# --------------------------------------------------------------------------- #
desc "Build projects in the current branch."
task :build, [:platform] do |_, e|
    e.with_defaults(:platform => PLATFORMS[0])
    Rake::Task[:restore].execute

    branch = `git rev-parse --abbrev-ref HEAD`.chomp
    build  = branch == 'net35' ?
             "msbuild -p:Configuration=Release" :
             "dotnet build -c Release"
    cmd(%(#{build} -p:Platform="#{e.platform}" #{PROJECT}.sln))
end

# --------------------------------------------------------------------------- #
# build_all
# --------------------------------------------------------------------------- #
desc "Build projects in pre-defined branches and platforms."
task :build_all do
    BRANCHES.product(PLATFORMS).each { |set|
        checkout(set[0]) do
            Rake::Task[:build].reenable
            Rake::Task[:build].invoke(set[1])
        end
    }
end

# --------------------------------------------------------------------------- #
# build_test
# --------------------------------------------------------------------------- #
desc "Build and test projects in the current branch."
task :build_test => [:build, :test]

# --------------------------------------------------------------------------- #
# test
# --------------------------------------------------------------------------- #
desc "Test projects in the current branch."
task :test do
    TESTS.each { |e| cmd(%(dotnet test -c Release "#{e}")) }
end

# --------------------------------------------------------------------------- #
# test_all
# --------------------------------------------------------------------------- #
desc "Test projects in pre-defined branches."
task :test_all do
    BRANCHES.each { |e| checkout(e) { Rake::Task[:test].execute }}
end

# --------------------------------------------------------------------------- #
# checkout
# --------------------------------------------------------------------------- #
def checkout(branch, &callback)
    sh("git checkout #{branch}")
    callback.call()
ensure
    sh("git checkout master")
end

# --------------------------------------------------------------------------- #
# cmd
# --------------------------------------------------------------------------- #
def cmd(args)
    sh("cmd.exe /c #{args}")
end
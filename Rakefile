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
REPOSITORY  = 'Cube.FileSystem'
BRANCHES    = ['stable', 'net35']
TESTCASES   = {"#{REPOSITORY}.Tests" => 'Tests'}

# --------------------------------------------------------------------------- #
# commands
# --------------------------------------------------------------------------- #
BUILD   = 'msbuild /t:Clean,Build /m /verbosity:minimal /p:Configuration=Release;Platform="Any CPU";GeneratePackageOnBuild=false'
PACK    = 'nuget pack -Properties "Configuration=Release;Platform=AnyCPU"'
TEST    = '../packages/NUnit.ConsoleRunner/3.10.0/tools/nunit3-console.exe'

# --------------------------------------------------------------------------- #
# clean
# --------------------------------------------------------------------------- #
CLEAN.include("#{REPOSITORY}.*.nupkg")
CLEAN.include("../packages/cube.*")
CLEAN.include(%w{bin obj}.map{ |e| "**/#{e}/*" })

# --------------------------------------------------------------------------- #
# default
# --------------------------------------------------------------------------- #
desc "Clean objects and pack NuGet package."
task :default => [:clean, :pack]

# --------------------------------------------------------------------------- #
# pack
# --------------------------------------------------------------------------- #
desc "Pack NuGet package in the net35 branch."
task :pack do
    BRANCHES.each { |e| Rake::Task[:build].invoke(e) }
    sh("git checkout net35")
    sh("#{PACK} Libraries/#{REPOSITORY}.nuspec")
    sh("git checkout master")
end

# --------------------------------------------------------------------------- #
# test
# --------------------------------------------------------------------------- #
desc "Build and test projects in the current branch."
task :test => [:build] do
    fw = `git symbolic-ref --short HEAD`.chomp
    fw = 'net45' if (fw != 'net35')
    TESTCASES.each { |proj, dir| sh("#{TEST} \"#{dir}/bin/Any CPU/Release/#{fw}/#{proj}.dll\"") }
end

# --------------------------------------------------------------------------- #
# build
# --------------------------------------------------------------------------- #
desc "Build the solution in the specified branch."
task :build, [:branch] do |_, e|
    e.with_defaults(branch: '')
    sh("git checkout #{e.branch}") if (!e.branch.empty?)
    sh("nuget restore #{REPOSITORY}.sln")
    sh("#{BUILD} #{REPOSITORY}.sln")
end
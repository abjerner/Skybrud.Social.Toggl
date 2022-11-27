@echo off
dotnet build src/Skybrud.Social.Toggl --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget
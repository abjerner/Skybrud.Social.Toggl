@echo off
dotnet build src/Skybrud.Social.Toggl --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget
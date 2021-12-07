@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Serialization.ElasticSearch\bin\Release\Panosen.Serialization.ElasticSearch.*.nupkg D:\LocalSavoryNuget\

pause
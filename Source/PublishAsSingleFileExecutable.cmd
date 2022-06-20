rem Running the command below will publish the application as a single-file executable.
rem This command was taken from a tutorial hosted at the URL
rem ""https://dotnetcoretutorials.com/2021/11/10/single-file-apps-in-net-6/"".
rem The resulting .exe file is, however, ridiculously heavyweight, at almost 62 MiB.
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained true
FROM microsoft/dotnet:1.1.4-runtime
MAINTAINER Mario-Leander Reimer <mario-leander.reimer@qaware.de>

WORKDIR /cloud-native-basta17
COPY out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "cloud-native-basta17.dll", "--server.urls", "http://0.0.0.0:5000"]
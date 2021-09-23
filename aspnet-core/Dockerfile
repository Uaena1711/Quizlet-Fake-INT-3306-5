FROM ubuntu:20.04

ARG DEBIAN_FRONTEND=noninteractive

RUN apt-get update && \
    apt-get -y upgrade && \
    apt-get -y install wget

# Get package from microsoft

RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb

# Install netcore 3.1 sdk 

RUN apt-get update && \
    apt-get install -y apt-transport-https && \
    apt-get install -y dotnet-sdk-3.1 && \
    apt-get install -y aspnetcore-runtime-3.1

# Work dir project
WORKDIR /app

# Copy all files into inmage
COPY . .

RUN dotnet restore

RUN cd src/Quizlet_Fake.DbMigrator; dotnet run; cd -

EXPOSE 44340

ENTRYPOINT [ "sh", "./run.sh" ]



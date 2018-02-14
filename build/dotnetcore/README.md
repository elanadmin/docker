### Install dotnetcore

```bash
https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x

### Useful Links:

    https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x
    https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?tabs=aspnetcore2x
    https://github.com/aspnet/Docs/blob/e9c1419175c4dd7e152df3746ba1df5935aaafd5/aspnetcore/publishing/linuxproduction.md
    http://files.zeroturnaround.com/pdf/zt_docker_cheat_sheet.pdf
    http://localcode.wikidot.com/net-core-on-linux
    https://gpawade.wordpress.com/2017/03/16/asp-net-core-sample-linux-hosting/

### dotnetcore-sample:
    https://github.com/gpawade/dotnetcore-sample
```

### Build and Publish App

```bash
    $ cd dotnetcore/
    $ dotnet --version
    $ dotnet --info
    $ dotnet clean
    $ dotnet restore
    $ dotnet build
    $ dotnet publish (This step will package your application into a self-contained directory that can run on your server)
```

### Docker Commands

```bash
    $ docker build -t nginx_dotnet -f dockerfile.supervisor  .
    $ docker run -d -p 80:80 -p 5000:5000 -p 9001:9001 -p 2222:22 -ti --name nginx_dotnet nginx_dotnet
    $ docker ps
    $ docker exec -it <containerid> bash
    $ docker rm -f <containerid>
    $ docker rmi <image>
```


# Dotnet core sample

```bash

    // Creating Solution file
    $ dotnet new sln
    $ mkdir src
    $ cd src
    :~/src$ dotnet new webapi -o HostApi && cd HostApi
    :~/src/HostApi$ dotnet build


    ## creating test project

    $ mkdir test
    $ cd test
    :~/test$ dotnet new xunit -o integrationtest && cd integrationtest
    :~/test/integrationtest$ dotnet restore


    ## add project reference
    :~/test/integrationtest$ dotnet add reference ../../src/HostApi/HostApi.csproj

    ## add nuget package reference
    :~/test/integrationtest$ dotnet add package Microsoft.AspNetCore.TestHost


    ## run the test
    $ dotnet test      # run the current project
    $ dotnet test test/integrationtest/integrationtest.csproj    

    ## run test with filter
    $ dotnet test --filter "Category=unittest"

    ## run test method
    $ dotnet test --filter "FullyQualifiedName=Namespace.ClassName.MethodName"



``` 


# Deployment in Ubuntu Server

## Supervisor
> Use supervisor to start our application on system boot and restart our process in the event of a failure.

### Installing Supervisor
```bash
    $ sudo apt-get install supervisor
```

### Configuring Supervisor

```bash
    $ cd /etc/supervisor/conf.d/

    # add new conf file for application
    $ sudo vi hellomvc.conf
```

> /etc/supervisor/conf.d/hellomvc.conf

```sh
    [program:hellomvc]
    command=/usr/bin/dotnet /var/site/HelloMVC.dll
    directory=/var/site/
    autostart=true
    autorestart=true
    stderr_logfile=/var/log/hellomvc.err.log
    stdout_logfile=/var/log/hellomvc.out.log
    environment=ASPNETCORE__ENVIRONMENT=Production
    user=www-data
    stopsignal=INT
```

> Restart the supervisor

```bash

    # stop and start the supervisor

    $ sudo service supervisor stop

    $ sudo service supervisor start

```

### Viewing log

```bash
    
    $ sudo tail -f /var/log/supervisor/supervisor.log
    # tail command print the last 10 line of file


    $ sudo tail -f /var/log/hellomvc.out.log 
```

## Configure a reverse proxy server

### Install

```bash
    $ sudo apt-get install nginx

    # start the ngnix
    $ sudo service ngnix start

```

### Configure Ngnix

Modify the file `/etc/ngnix/site-available/default`

```sh
server {
    listen 80;
    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

#### Verify changes

```bash
    # Verify the syntax of your configuration files
    $ sudo ngnix -t

    # reload the ngnix
    $ sudo ngnix -s reload
```

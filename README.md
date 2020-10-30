# My Broken Page

<details>
    <summary>Table of contents</summary>

- [Introduction](#introduction)

- [Installation](#installation)
  - [Ubuntu](#ubuntu)
    - [Option A - Docker](#ubuntu-docker)
    - [Option B - Manual](#ubuntu-manual)
      - [Installing .NET Core 3.1 SDK](#ubuntu-install-dotnet-core)
      - [Download front-end libraries](#ubuntu-front-end)
      - [Database management](#ubuntu-database-management)
        - [Installing SQL Server](#ubuntu-installing-sql-server)
        - [Installing Entity Framework Core](#ubuntu-installing-ef-core)
        - [Database initialization](#ubuntu-db-init)

</details>

## <a name="introduction"></a> Introduction

*My Broken Page* is a web application developed with the goal of helping developers to better understand the exploitation and effects of the most common web vulnerabilities. The application also aims to provide as much visual feedback,instructions and explanations as possible.

Disclaimer: If you're looking for a vulnerable application to learn more about web exploiation you might want to look for something else. This application might be useful only if you're just starting to learn about this.

![Gif Login SQLi](https://user-images.githubusercontent.com/38787278/97672790-509e5300-1a93-11eb-9bed-47e2bc874a76.gif)

## <a name="installation"></a> Installation

>TODO:
>
> - scripts for automating the installation
>
> - Windows guide

### <a name="ubuntu"></a> Ubuntu

*This was tested on Ubuntu 20.04. Depending on your Linux ditro you may need to adjust the below commands.*

#### <a name="ubuntu-docker"></a> Option A - Docker

Make sure you have [docker](https://docs.docker.com/engine/install/) and [docker-compose](https://docs.docker.com/compose/install/) installed and run the next commands:

```bash
cd my-broken-page
sudo docker-compose build
sudo docker-compose up
```

Go to `localhost:9080/login`, enter as username `admin' OR 1=1 --` and any password that's not blank. If you are logged in than everything worked fine.

If you got an error about the docker-compose version follow the next steps:

Check the docker engine version you have installed with:

```bash
docker version
```

Take a look at this [table](https://docs.docker.com/compose/compose-file/) and pick the docker-compose version associated with you docker engine version. Next, change the value of `version` from `docker-compose.yml` accordengly and try again to build and run the container.

#### <a name="ubuntu-manual"></a> Option B - Manual

##### <a name="ubuntu-install-dotnet-core"></a> Installing .NET Core 3.1 SDK

Dependencies:

```bash
sudo apt-get install -y apt-transport-https
```

Add the Microsoft package signing key to your list of trusted keys and add the package repository (this needs to be done before installing the SDK):

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

Install .NET Core SDK 3.1:

```bash
sudo apt-get install -y dotnet-sdk-3.1
```

Take the repository:

```bash
git clone https://github.com/saw-your-packet/my-broken-page.git
cd my-broken-page
git checkout develop
git pull origin develop
```

Test if application runs (make sure you are inside the repo directory):

```bash
cd src/MyBrokenPage.UI # move to the irectory with the web app
dotnet run MyBrokenPage.UI.csproj # start the web application
```

By default the application should start on port `5000` for http, but you can check the command output to make sure.

Navigate to `localhost:5000`. If everything worked fine you should be prompted with a web page that misses styling. If that's the case, hit `Ctrl + C` to stop the web application and move to the next step.

If something didn't work, check the [Microsoft installation documentation](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

##### <a name="ubuntu-front-end"></a> Download front-end libraries

The project uses `libman` for installing and restoring front-end libraries. To install `libman` you need to run:

```bash
dotnet tool install -g Microsoft.Web.LibraryManager.Cli # -g is for global
```

Check if it was installed correctly by running `libman --version`. If you received an error check again the above command and make sure `dotnet` installed correctly.

Before getting the libraries, make sure you are inside the folder of the web application (`src/MyBrokenPage.UI`) and that the file `libman.json` is present.

Now run:

```bash
libman restore
```

If something didn't work, check the [Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-3.1).

After it finishes, start the application with `dotnet run MyBrokenPage.UI.csproj` and check if the styling was applied.

##### <a name="ubuntu-database-management"></a> Database management

The application uses SQL Server and Entity Framework Core 3 for database operations.

###### <a name="ubuntu-installing-sql-server"></a> Installing SQL Server

Add GPG keys:

```bash
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
```

Register the Microsoft SQL Server Ubuntu repository:

```bash
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/18.04/mssql-server-2019.list)"
```

Install SQL server:

```bash
sudo apt-get update
sudo apt-get install -y mssql-server
```

Coniguration:

```bash
sudo /opt/mssql/bin/mssql-conf setup
```

Here you are promped with a series of steps:

1. Choose edition
    Enter `2` for `Developer`.

    ```text
    usermod: no changes
    Choose an edition of SQL Server:
    1) Evaluation (free, no production use rights, 180-day limit)
    2) Developer (free, no production use rights)
    3) Express (free)
    4) Web (PAID)
    5) Standard (PAID)
    6) Enterprise (PAID) - CPU Core utilization restricted to 20 physical/40 hyperthreaded
    7) Enterprise Core (PAID) - CPU Core utilization up to Operating System Maximum
    8) I bought a license through a retail sales channel and have a product key to enter.

    Details about editions can be found at
    https://go.microsoft.com/fwlink/?LinkId=2109348&clcid=0x409

    Use of PAID editions of this software requires separate licensing through a
    Microsoft Volume Licensing program.
    By choosing a PAID edition, you are verifying that you have the appropriate
    number of licenses in place to install and run this software.

    Enter your edition(1-8): 2
    ```

2. License agreement

    Enter `Yes` if you agree with the lincese terms.

    ```text
    The license terms for this product can be found in
    /usr/share/doc/mssql-server or downloaded from:
    https://go.microsoft.com/fwlink/?LinkId=2104294&clcid=0x409

    The privacy statement can be viewed at:
    https://go.microsoft.com/fwlink/?LinkId=853010&clcid=0x409

    Do you accept the license terms? [Yes/No]:Yes
    ```

3. Password configuration
    Enter a strong password for system adminsitrator. If you're planning to make the SQL Server exposed externally choose a really good password. Note this password, you'll need it later.

    ```text
    Enter the SQL Server system administrator password:
    Confirm the SQL Server system administrator password:
    ```

4. Autoconfiguration
    Now the isntaller will do the last configuration automatically. At the end you should be prompted with `Setup has completed successfully. SQL Server is now starting.` if everything worked corectly.

If you encounter problems, please check the [Microsoft Documentation](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-ubuntu?view=sql-server-ver15#install)

Check if SQL Server is running:

```bash
systemctl status mssql-server --no-pager
```

If the service is not running you can start it with:

```bash
systemctl start mssql-server
```

###### <a name="ubuntu-installing-ef-core"></a> Installing Entity Framework Core

The application uses this package as ORM.

Install EF Core:

```bash
dotnet tool install --global dotnet-ef
```

Check installation with:

```bash
dotnet ef
```

Check the [Microsoft documentation](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#installing-the-tools) if you encountered any issues.

###### <a name="ubuntu-db-init"></a> Database initialization

Navigate to `MyBrokenPage.Dal.Design`. If you are currently in `MyBrokenPage.UI` you can run:

```bash
cd ../MyBrokenPage.Dal.Design
```

The same authentication mechanism used on Windows is not availble on Linux, so we need to change the connection string with the credentials used at the configuration step. Open in an editor the `MyBrokenPageContextFactory.cs` file as shown below:

```bash
gedit MyBrokenPageContextFactory.cs
```

Now you must make the next changes:

1. Replace the connection string with `"Data Source=(local);Initial Catalog=MyBrokenPage;User=sa;Password=your-password;"`

2. Change the `Password` field with the password used for configuring the SQL Server

In the end you should end up with something like:

Initialize and populate database with:

```bash
dotnet ef database update
```

Let's test if the database was correctly initialized by navigating to the folder of the web application and starting it.

Now go to `localhost:5000/login`, enter as usename `admin' AND 1=1 --` and everything that's not blank as password. If you are logged in, then everything worked fine.

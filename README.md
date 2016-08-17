<h1> VEGE portal</h1>

The "VEGE portal" is the codename for VEGE's new software containing tools like searching, news, reporting, data management etc.
Please feel free to check the source by navigating to the "files" tab on the left. All the class libraries + UI layer is found in the 'src' folder.

<h2>Version</h2>
1.2.0

<h2>Installation</h2>

VEGE portal was created in Visual Studio 2015 enterprise edition.

If you wish to open this project in Visual studio yourself, please make sure that you have .net 4.5.2+ installed as all the projects in the solution are depending on this.
<br />
<br />
### Requirements (Visual Studio + git)
<br />
 * Make sure Visual studio is installed (Recommended version: 2015+)
 * Download git for your operating system and install: https://git-scm.com/downloads
 * Once installation is finished, open up the newly installed software 'Git bash'
 * Type the following commands in the Git bash to finish installation and download of VEGE Portal 
<br />
<br />
 
 <hr>
### Generate SSH Key and add to GitLab
```sh
ssh-keygen
```
This will create a new ssh key (default name: id_rsa.pub) under the following windows path: %userprofile%\\.ssh
open this file in notepad and copy all the content.
<br />

Open the following GitLab url: http://vglx01.vege.nl:9999/profile/keys/new and paste all it's content in the 'Key' box.
Then hit save.
<hr>

<br />

<hr>
### Download latest version of VEGE Portal
```sh
mkdir repositories
cd repositories
git clone git@vglx01.vege.nl:root/Vege.Portal.git
```

That's it! The latest version of VEGE Portal is now downloaded and located in the repositories folder in your user profile path.
To open the solution, simply double click the .vs file.
<br />
<br />
Now, whenever there is an update to the project. All you have to do to get this locally on your computer is run the following commands in git bash:
```sh
cd repositories
git fetch git@vglx01.vege.nl:root/Vege.Portal.git
```
<hr>
<br />
<br />

<h2>Tech</h2>

* Most of the VEGE portal is based upon dependency injection. It is using Ninject as it's dependency injector.
* Repository pattern implemented
* VEGE Portal strive for DD-development but is currently a mix between DDD and 3-layer architecture
* MVVM, model-first.

<br />
<br />


<h2> Packages</h2>

The VEGE portal was originally developed together with Microsoft's official ado.net package, Entity Framework, but has since been moved over to Dapper for much better DAL performance.

Below is a summary of the main packages implemented in the VEGE Portal.

 * Ninject - 3.2.2.0
 * NLog - 4.2.3
 * Dapper - 1.42
 * Dapper.Tvp - 1.0.0
 * Entity Framework - 6.1.3
 * Caliburn.micro - 2.0.2
 * Caliburn.micro core - 2.0.2


<h2>Development</h2>

   * Joakim Hansson - Lead developer
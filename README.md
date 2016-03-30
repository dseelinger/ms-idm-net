# ms-idm-net
Microsoft Identity Manager .NET interface

This is a simple-to-use .NET implementation of an API to access Microsoft's Identity Manger Service (MIM/FIM).

## Connecting to your MIM/FIM server
To use this in your environment, edit settings Setup-Env.ps1 for your particular environment and then run it.  Note
that you may need to restart Visual Studio in order for your changes to take effect

Or, you can set the following values manually as either environment variables or in an App.config:
- MIM_fqdn - the fully-qualified domain name of your MIM/FIM server (eg. myfimserver.mycompany.com) or its IP address
- MIM_username - Account name that will be used to access the MIM/FIM Service
- MIM_pwd - Password for the account
- MIM_domain - Account's domain

MSDN-type documentation can be found at http://dseelinger.github.io/ms-idm-net

The best place to go for examples on how to use the various features of this API is https://github.com/dseelinger/ms-idm-net/blob/master/IdmNet/IdmNet.Tests/IdmNetClientTests.cs

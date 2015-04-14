[Environment]::SetEnvironmentVariable("MIM_fqdn", "your fully qualified domain name of the Identity Manager server(s), like idm.contoso.com", "User") #used for both the Identity Manager Service address and SPN
[Environment]::SetEnvironmentVariable("MIM_domain", "contoso", "User")
[Environment]::SetEnvironmentVariable("MIM_pwd", "whatever your password is", "User")
[Environment]::SetEnvironmentVariable("MIM_username", "an account that has permissions in Identity Manager", "User")
         

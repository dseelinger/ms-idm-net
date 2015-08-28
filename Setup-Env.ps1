$fqdn = Read-Host "Your fully qualified domain name of the Identity Manager server(s), like idm.contoso.com"
$domain = Read-Host "Your domain name"
$username = Read-Host "Fim Access Username"
$password = Read-Host "Fim Access Password"

#choice menu (good version)
$options = [String[]]("Machine", "User", "Exit") #always have Exit be the last of the array
function PrintOptions
{
	$num = 1
	foreach ($option in $options)
	{
		if($option -eq "Exit")
		{
			Write-Host "$num. $option" -ForegroundColor Yellow
		}
		else
		{
			Write-Host "$num. $option"
		}
		$num++
	}
}
while ($choice -lt 1 -or $choice -gt $options.length)
{
	PrintOptions
	[int]$choice = Read-Host "Select an Environment"
}

$Environment = $options[$choice - 1]

if($Environment -eq "Exit")
{
	exit
}

if($Environment -eq "Machine")
{
#Check for Admin Priviledges
	If (-NOT ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(`
		[Security.Principal.WindowsBuiltInRole] "Administrator"))
	{
		Write-Warning "You do not have Administrator rights to run this script!`nPlease re-run this script as an Administrator!`n(Right-Click Powershell Icon, Click 'Run as Administrator')"
		Break
	}
}

[Environment]::SetEnvironmentVariable("MIM_fqdn", "$fqdn", "$Environment") #used for both the Identity Manager Service address and SPN
[Environment]::SetEnvironmentVariable("MIM_domain", "$domain", "$Environment")
[Environment]::SetEnvironmentVariable("MIM_pwd", "$username", "$Environment")
[Environment]::SetEnvironmentVariable("MIM_username", "$password", "$Environment")
		 
Write-Host "Script Complete"

$module = "..\packages\psake.4.4.2\tools\psake.psm1"

clear

# patching the $PSScriptRoot if needed
if($PSScriptRoot -eq ""){
	$PSScriptRoot = "."
}

# Test the psake package existence
if ((Test-Path $module) -ne $true) {
    .\NuGet.exe restore "..\..\.nuget\packages.config" -SolutionDirectory "..\"
}

# Importing psake module
Import-Module $module -force

# Repassing received parameters for main script
if ($MyInvocation.UnboundArguments.Count -ne 0) {
	Invoke-psake -taskList ($MyInvocation.UnboundArguments -join " ") -framework "4.6"
} else {
	Invoke-psake -framework "4.6"
}
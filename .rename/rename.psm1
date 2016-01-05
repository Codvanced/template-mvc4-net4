function StartRenamer {
	[CmdletBinding()]
    param(
        [Parameter(Position = 0, Mandatory = 0)][string] $customer,
        [Parameter(Position = 1, Mandatory = 0)][string] $project,
		[Parameter(Position = 2, Mandatory = 0)][string] $dir
    )

	try { 
		.\IOC.FW.Renamer.exe $customer $project $dir
	}
	catch {

	}
}
 
Export-ModuleMember -Function StartRenamer


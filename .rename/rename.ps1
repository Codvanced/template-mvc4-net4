Import-Module .\rename.psm1
$outputFolder = "..\app"

Write-Host "Nome do cliente: "
$customer = Read-Host

Write-Host "Nome do projeto: "
$project = Read-Host

if ($customer -ne "" -and $project -ne "") {
	Write-Host "Renomeando template para os dados fornecidos: '$customer.$project'"
	
	if ((Test-Path $outputFolder) -ne $true) {
		mkdir $outputFolder
	} 
	
	Remove-Item $outputFolder\* -Confirm:$false -Recurse	
	xcopy /S /Y ..\template\*.* $outputFolder 
	StartRenamer $customer $project $outputFolder
}

Remove-Module rename

cd $outputFolder\.build\

.\build.ps1

del **\*.pdb
#This build assumes the following directory structure
#
#  \Build          - This is where the project build code lives
#  \BuildArtifacts - This folder is created if it is missing and contains output of the build
#  \Code           - This folder contains the source code or solutions you want to build
#
Properties {
	$build_dir = Split-Path $psake.build_script_file
	$projectName = "NAME_REPLACE"
	$build_artifacts_dir = "..\BuildArtifacts\"
	$code_dir = ".."
	$sln = "$code_dir\$projectName.WebMvcApp.sln"
}

FormatTaskName (("-"*25) + "[{0}]" + ("-"*25))

Task Default -Depends BuildRelease

Task BuildRelease -Depends Restore, Clean, Build

Task Restore {
	..\.build\nuget.exe restore $sln
}

#-Depends Clean
Task Build  {
	Write-Host "Building $sln" -ForegroundColor Green
	Exec { msbuild $sln /t:Build /p:Configuration=Release /v:quiet /p:OutDir=$build_artifacts_dir }
	del "$build_artifacts_dir\*.pdb"
	del "$build_artifacts_dir\*.xml"
}

Task Clean {
	Write-Host "Creating BuildArtifacts directory" -ForegroundColor Green
	if (Test-Path $build_artifacts_dir) {
		rd $build_artifacts_dir -rec -force | out-null
	}
	
	mkdir $build_artifacts_dir | out-null
	
	Write-Host "Cleaning $sln" -ForegroundColor Green
	Exec { msbuild $sln /t:Clean /p:Configuration=Release /v:quiet }
}
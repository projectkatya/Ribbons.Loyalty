param(
	[Parameter(Mandatory=$True)] [string] $context,
	[Parameter(Mandatory=$True)] [string] $migrationName
)

$providers = @("MsSql", "MySql", "NpgSql", "Oracle", "Sqlite")
$projectPath = "Ribbons.Loyalty.Data/Ribbons.Loyalty.Data.csproj";

foreach($provider in $providers) {
	$outputPath = "Migrations/${context}Migrations/${provider}"
	$providerContext = "${context}${provider}"
	Write-Output("Creating migrations for ${context} for provider ${provider} in ${outputPath}");
	dotnet ef migrations add $migrationName --project $projectPath --context $providerContext --output-dir $outputPath
}


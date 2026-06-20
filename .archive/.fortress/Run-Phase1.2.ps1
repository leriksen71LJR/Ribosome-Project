<#
.SYNOPSIS
    Prepares and runs Phase 1.2 builds sequentially for Claude, Grok Build, and Codex.
.DESCRIPTION
    This script copies the latest documentation into each agent folder and prepares the environment.
    It runs sequentially (one agent at a time).
.PARAMETER ClaudePath
    Full path to the Claude project folder (e.g. C:\Users\lerik\source\repos\fortress-shootout\Claude)
.PARAMETER GrokPath
    Full path to the Grok Build project folder
.PARAMETER CortexPath
    Full path to the Codex project folder
.EXAMPLE
    .\Run-Phase1.2.ps1 -ClaudePath "C:\...\Claude" -GrokPath "C:\...\Grok" -CortexPath "C:\...\Cortex"
#>

param(
    [Parameter(Mandatory=$true)]
    [string]$ClaudePath,

    [Parameter(Mandatory=$true)]
    [string]$GrokPath,

    [Parameter(Mandatory=$true)]
    [string]$CortexPath
)

$ErrorActionPreference = "Stop"

Write-Host "=== Phase 1.2 Sequential Build Runner ===" -ForegroundColor Cyan
Write-Host ""

$folders = @(
    @{ Name = "Claude";   Path = $ClaudePath },
    @{ Name = "Grok";     Path = $GrokPath },
    @{ Name = "Cortex";   Path = $CortexPath }
)

foreach ($folder in $folders) {
    Write-Host ">>> Preparing $($folder.Name)..." -ForegroundColor Yellow

    if (-not (Test-Path $folder.Path)) {
        Write-Error "Path does not exist: $($folder.Path)"
        continue
    }

    $docsDest = Join-Path $folder.Path ".docs"

    # Copy latest documentation
    Write-Host "   Copying .docs/ ..." -ForegroundColor Gray
    if (Test-Path $docsDest) {
        Remove-Item $docsDest -Recurse -Force
    }
    Copy-Item ".docs" -Destination $docsDest -Recurse -Force

    # Ensure Builds folder exists
    $buildsPath = Join-Path $docsDest "Builds"
    if (-not (Test-Path $buildsPath)) {
        New-Item -ItemType Directory -Path $buildsPath | Out-Null
    }

    Write-Host "   Done preparing $($folder.Name)" -ForegroundColor Green
    Write-Host ""
}

Write-Host "=== All folders prepared ===" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor White
Write-Host "1. Open each folder in your file explorer or terminal."
Write-Host "2. Start the respective agent using the prompt in .docs/Prompts/Phase-1.2/"
Write-Host ""
Write-Host "Script completed successfully." -ForegroundColor Green
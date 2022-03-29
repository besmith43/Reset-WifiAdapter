# got from http://woshub.com/check-powershell-script-running-elevated/

#requires -version 5.0

#requires -RunAsAdministrator
    
Write-Host "Disabling Wifi Adapter"

Get-NetAdapter -Name Wi-Fi | Disable-NetAdapter

Start-Sleep -Seconds 2

Write-Host "Enabling Wifi Adapter"

Get-NetAdapter -Name Wi-Fi | Enable-NetAdapter


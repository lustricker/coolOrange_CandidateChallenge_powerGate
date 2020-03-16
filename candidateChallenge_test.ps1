Import-Module powerGate
Connect-ERP -Service "http://$($ENV:Computername):8080/CandidateChallenge/Employee_Service"

$allEmployees = Get-ERPObjects -EntitySet "Employees"

$newEmployee = New-ERPObject -EntityType "Employee" -Properties @{Name = "CoolOrange_Candidate"; Email = "test@gmail.com"; City = "Meran"; Department = "Department"}
Add-ERPObject -EntitySet "Employees" -Properties $newEmployee
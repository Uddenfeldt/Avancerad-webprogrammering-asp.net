# ÖVNINGSUPPGIFTER I POWERSHELL

# ---- Intro --------------------------------------------------

# Bra kortkommandon i PowerShell ISE:

# Go to Script Pane    Ctrl+I
# Go to Console        Ctrl+D
# Run Selection        F8
# Run Script           F5

# F8 är din vän

# Grundläggande Powershell kommandon: https://technet.microsoft.com/en-us/library/hh551144.aspx

# ---- Uppgifter --------------------------------------------------

# Hämta dagens datum
Get-Date

# Lista alla services
Get-Service

# Visa de tre första service's

$service= Get-Service
$service[0]
$service[1]
$service[2]

# Visa namn på de tre första

$service= (Get-Service).Name
$service[0]
$service[1]
$service[2]

# Visa alla processer

Get-Process

# Visa de tre första processerna
$process = Get-Process
$process[0]
$process[1]
$process[2]

# Deklarera en variabel "weekday" och sätt den till "torsdag"

$weekday = 'torsdag'

# Deklarera en lista av de fem första primtalen
$numbersArray = 1,3,5,7,11
$numbersArray

# Vad händer om du försöker skriva ut en variabel som inte är deklarerad?

# Skriv ut en grön text i consolen

$var='hello'
write-host ('hello') -foreground "green"

# Skriv ut en röd text med gul bakgrund
write-host ('hello') -foreground "red" -BackgroundColor Yellow

# Skapa en variabel $fruit och sätt den till ett värde.

$fruit='äpple'


# Finns det något lättare sätta att skriva detta:
# "Ge mig ett " + $fruit
"Ge mig ett ${fruit}" 

# Hämta alla filer under mappen "C:\Users"
Get-Childitem –Path C:\Users

# Hämta alla filer under mappen "C:\Users" - men skriv bara ut namnen på filerna/
$var=(Get-Childitem -Path C:\Users).Name   
$var

# Hämta alla filer under mappen "C:\Users" - sortera på namn
$var=(Get-Childitem -Path C:\Users).  
$var

# Hämta alla filer under mappen "C:\Users" - sortera på namn i omvänd ordning

# Samma som föregående uppgift men skriv bara ut namn

# Skriv ut den fullständiga sökvägen till alla filer/mappar under "C:\Users"


# Skriv ut den fullständiga sökvägen till alla filer/mappar under "C:\Users"

C:\Users\defaultuser0
C:\Users\happy       
C:\Users\nanni       
C:\Users\Public    

# Visa tabell med filer/mappar under "C:\Users", men bara skapatdatum och namn

2017-09-08 8:55:09 AM  defaultuser0
2017-09-08 8:55:08 AM  happy       
2017-11-04 6:25:14 PM  nanni       
2017-03-18 10:03:29 PM Public   


# Skriv ut namnen på alla filer/mappar under "C:\Users" men med grön text 
# Lös uppgiften med ForEach-Object

# Samma som ovan men lös utan att använda ForEach-Object (det blir kortare kod)

# Skriv ut LastWriteTime på alla filer/mappar under "C:\Users". I grönt. Använd inte ForEach-Object

# Hämta den fil/mapp i "C:\Users" som senast ändrades

# Skriv ut följande miljövariabler: datornamn, sökväg till Program Files, sökväg till windowskatalogen

# Lista allt du kan göra med en sträng. 

Name             MemberType            Definition                                                      
----             ----------            ----------                                                      
Clone            Method                System.Object Clone(), System.Object ICloneable.Clone()         
CompareTo        Method                int CompareTo(System.Object value), int CompareTo(string strB...
Contains         Method                bool Contains(string value)                                     
....
....

# Lägg alla service's i en variabel. Visa sedan namnet på den tredje service'n

# Samma som ovan, men gör det på en rad utan att skapa en variabel

# Skapa en scriptfil hello.ps1. Inparameterar till filen ska vara:
# firstname, age och toupper
# Det ska finnas defaultvärden för alla 
# Här har vi kört programmet fem gånger. Svara med ett välkomsttext, på samma sätt.

PS C:\Project\AvanceradWebbutv\Uppgifter\Powershell> .\hello.ps1
Hej Sven! Om 30 år är du 80 år gammal

PS C:\Project\AvanceradWebbutv\Uppgifter\Powershell> .\hello.ps1 -firstname Lisa
Hej Lisa! Om 30 år är du 80 år gammal

PS C:\Project\AvanceradWebbutv\Uppgifter\Powershell> .\hello.ps1 -firstname Lisa -age 23
Hej Lisa! Om 30 år är du 53 år gammal

PS C:\Project\AvanceradWebbutv\Uppgifter\Powershell> .\hello.ps1 -firstname Lisa -age 23 -toupper yes
HEJ LISA! OM 30 ÅR ÄR DU 53 ÅR GAMMAL

PS C:\Project\AvanceradWebbutv\Uppgifter\Powershell> .\hello.ps1 -firstname Lisa -age 23 -toupper no
Hej Lisa! Om 30 år är du 53 år gammal

 
# Visa innehållet i filen colors.txt

# Visa andra färgen i filen colors.txt

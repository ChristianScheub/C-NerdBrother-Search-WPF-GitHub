# C-NerdBrother-Search-WPF-GitHub
Last Edit: 08.2018
Language: C# Windows Forms

This is a simple C# Windows Form Tool which crap news sites and other sites and store all meta-tags which were used for the articles/sub sites.
After this you can search through these tags. The search results will sort themselves over time according to your preferences.

Database Structure:
Art(ID_Typ,TypName)
Beziehung(ID,ID_Typ,Webseite_ID)
Sites(ID_Webseite,Namen,Links,Klicks,Beschreibung,Abrufdatum)

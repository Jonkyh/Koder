Attribute VB_Name = "Module2"
Sub Gammel_Tilpas_Projekt_og_Aktivitetsnr()
    Dim ws As Worksheet
    Dim lastRow As Long
    Dim r As Long
    Dim Projekt_nr As String
    Dim Aktivitet_nr As String
    Dim splitValue As Variant
    Dim currentMonth As String
    
    ' Definerer det aktive ark
    Set ws = ActiveSheet

    ' Flytter række 6 til række 2
    ws.Rows(6).Copy
    ws.Rows(2).Insert Shift:=xlDown
    
    ' Indsætter tre nye kolonner til venstre
    ws.Columns("A").Insert Shift:=xlToRight
    ws.Columns("A").Insert Shift:=xlToRight
    ws.Columns("A").Insert Shift:=xlToRight
    
    ' Flytter overskriften fra række 3 til A1
    ws.Cells(1, 1).Value = ws.Cells(5, 3).Value
    ws.Cells(1, 1).Font.Bold = True
    ws.Cells(1, 1).Font.Size = 14
    
    ' Sætter kolonneoverskrifter
    ws.Cells(2, 1).Value = "Måned"
    ws.Cells(2, 2).Value = "Projektnr"
    ws.Cells(2, 3).Value = "Aktivitetsnr"
    
    ws.Cells(2, 1).Font.Bold = True
    ws.Cells(2, 2).Font.Bold = True
    ws.Cells(2, 3).Font.Bold = True

    ' Finder den sidste række med data
    lastRow = ws.Cells(ws.Rows.Count, 4).End(xlUp).Row ' Antager at kolonne D har data

    ' Henter den aktuelle måned som tekst
    currentMonth = Format(Date, "mmmm yyyy") ' F.eks. "Februar 2025"

    ' Gennemgår rækker fra række 3 og ned for at hente Projektnr og Aktivitetsnr
    For r = 3 To lastRow
        If InStr(1, ws.Cells(r, 4).Value, "Projektkort for projekt") > 0 Then
            ' Henter projekt nummeret
            Projekt_nr = Trim(Mid(ws.Cells(r, 4).Value, InStr(1, ws.Cells(r, 4).Value, "Projektkort for projekt") + 24, 10))
            Projekt_nr = Split(Projekt_nr, " ")(0) ' Henter kun første tal
        End If
        
        ' Finder aktivitetsnummeret
        If Not IsEmpty(ws.Cells(r, 4).Value) Then
            splitValue = Split(ws.Cells(r, 4).Value, " ")
            If UBound(splitValue) >= 0 Then
                If IsNumeric(splitValue(0)) And Not IsDate(splitValue(0)) Then
                    Aktivitet_nr = splitValue(0) ' Henter første tal før første mellemrum, kun hvis det er et tal og ikke en dato
                End If
            End If
        End If
        
        ' Udfylder kolonnerne med de aktuelle værdier
        ws.Cells(r, 1).Value = currentMonth ' Tilføjer den aktuelle måned i første kolonne
        If Not IsEmpty(Projekt_nr) Then ws.Cells(r, 2).Value = Projekt_nr
        If Not IsEmpty(Aktivitet_nr) Then ws.Cells(r, 3).Value = Aktivitet_nr
    Next r
    
    ' Slet rækker hvor kolonne D ikke indeholder en dato
    For r = lastRow To 3 Step -1
        If Not IsDate(ws.Cells(r, 4).Value) Then
            ws.Rows(r).Delete Shift:=xlUp
        End If
    Next r
    
    ' Juster kolonnebredde til 20
    ws.Columns("A:Z").ColumnWidth = 20
    
    MsgBox "Kolonner, projektnr, aktivitetsnr og måned er opdateret!", vbInformation
End Sub


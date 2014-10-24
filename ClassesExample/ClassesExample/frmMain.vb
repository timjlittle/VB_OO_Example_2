Public Class frmMain
    Private isNew As Boolean = True
    Private listIndex As Integer = -1

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim creature As Mammal
        Dim allOK As Boolean = True
        Dim errorMsg As String = ""

        If txtName.Text = "" Then
            allOK = False
            errorMsg = "Please specify a name" & vbCrLf
        End If

        If cboType.Text = "" Then
            allOK = False
            errorMsg = "Please specify a what type of creature" & vbCrLf
        End If

        If allOK Then
            'It is impossible to create a new thing of type Mammal (abstract), you need the actual species
            Select Case cboType.Text
                Case "Bat"
                    creature = New Bat(txtName.Text, datDOB.Value)

                Case "Cat"
                    creature = New Cat(txtName.Text, datDOB.Value)

                Case "Dog"
                    creature = New Dog(txtName.Text, datDOB.Value)

                Case "Human"
                    creature = New Human(txtName.Text, datDOB.Value)

                Case Else
                    MsgBox("Please select a type")
                    allOK = False
            End Select

            If allOK Then
                'If it is new add to the list
                If isNew Or listIndex < 0 Then
                    lstAnimals.Items.Add(creature)
                Else
                    'Otherwise update the existing value
                    lstAnimals.Items(listIndex) = creature
                End If
                txtNotes.Text = getInfo(creature)
            End If
        Else
            MsgBox(errorMsg)
        End If
    End Sub

    Private Function getInfo(ByRef creature As Mammal) As String
        Dim retStr As String = ""

        retStr = creature.name & " is a " & creature.species & ". It's age is " & creature.age
        retStr = retStr & ". It says " & creature.noise & " and is "
        If creature.canFly Then
            retStr = retStr & "able "
        Else
            retStr = retStr & "not able "
        End If
        retStr = retStr & "to fly. It's special because it " & creature.info

        getInfo = retStr
    End Function


    Private Sub lstAnimals_Click(sender As Object, e As System.EventArgs) Handles lstAnimals.Click
        Dim creature As Mammal

        creature = lstAnimals.SelectedItem
        listIndex = lstAnimals.SelectedIndex
        isNew = False

        txtName.Text = creature.name
        datDOB.Value = creature.DoB
        cboType.Text = creature.species
        txtNotes.Text = getInfo(creature)

    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        listIndex = -1
        isNew = True

        txtName.Text = ""
        txtNotes.Text = ""
        datDOB.Value = Now()
        cboType.Text = ""
    End Sub
End Class



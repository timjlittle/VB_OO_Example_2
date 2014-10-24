'******************************************************************************************************************
'* This is an example of an concrete class of the type Mammal
'* Because it inherits from the Mammal class it doesn't need to
'* implement functions in that class (although it could)
'******************************************************************************************************************

Public Class Human : Inherits Mammal
    'Local constructor. Must call parent class constructor first
    Public Sub New(ByVal newName As String, ByVal newDoB As Date)
        MyBase.New(newName, newDoB)

        legCount = 4
        mySpecies = "human"
    End Sub

    'Implementation of abstract (undefined) functions in the Mammal class
    Public Overrides ReadOnly Property canFly As Boolean
        Get
            canFly = False
        End Get
    End Property

    Public Overrides Function info() As String
        Return " makes tools."
    End Function

    Public Overrides Function noise() As String
        noise = "blah, blah, blah"
    End Function

End Class

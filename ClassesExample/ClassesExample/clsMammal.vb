'******************************************************************************************************************
'* This is an example of an abstract class, you can't create actual examples of type Mammal they need to be
'* examples of species using sub classes such as the classes Dog, Cat, Bat or Human (see other class files).
'* 
'* The abstract class implements features that are shared with all mammals and specifies features that the 
'* subclasses must implement using the mustoverride keyword
'*
'******************************************************************************************************************

Public MustInherit Class Mammal
    '* Class variables. Protected means visible to sub classes such as Dog, but not outside
    Protected myName As String
    Protected legCount As Integer
    Protected myDoB As Date
    Protected mySpecies As String

    Public Sub New(ByVal newName As String, ByVal newDoB As Date)
        myName = newName
        myDoB = newDoB
    End Sub

    '* Global functions, subs and properties inherited by subclasses
    Public ReadOnly Property name As String
        Get
            Return myName
        End Get
    End Property

    Public ReadOnly Property species As String
        Get
            Return mySpecies
        End Get
    End Property

    Public Overrides Function toString() As String
        Return myName
    End Function

    Public ReadOnly Property age As Integer
        Get
            age = DateDiff(DateInterval.Year, myDoB, Now())
        End Get
    End Property

    Public ReadOnly Property legs As Integer
        Get
            Return legCount
        End Get
    End Property

    Public ReadOnly Property DoB As Date
        Get
            DoB = myDoB
        End Get
    End Property

    'Abstract functions, these must be implemented by the concrete classes
    Public MustOverride ReadOnly Property canFly As Boolean
    Public MustOverride Function info() As String
    Public MustOverride Function noise() As String


End Class


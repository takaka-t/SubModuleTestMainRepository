Imports EnumExtention

<TestClass()> Public Class UnitTest1

    'Enum Test1 As Byte
    '    <EnumStringValue("aaa")>
    '    AAA
    '    BBB
    '    CCC
    'End Enum


    <TestMethod()>
    Public Sub TestMethod1()
        'Test1.AAA.StringValue
        'Test1.Get
        'Dim list = [Enum].GetValues(GetType(Test1))

        'Dim a = New Test1
        'a.GetValues1()
        'Dim b = GetType(Test1)
        'Dim a = New Test1().

        'Dim c = [Enum].GetUnderlyingType(GetType(Test1))
        'Dim d = [Enum].GetValues(GetType(Test1))
        'Dim e = [Enum].GetValues(GetType(Test1)).Find(Function(x) x)
        '[Enum].
        '(GetType(Test1))

        Dim a = Test1.GetAll
        Console.WriteLine(a(1))

        Dim b = Test1.GetItem(2)
        Console.WriteLine(b.Name)
    End Sub

    Public ReadOnly AAA As (Value As Integer, Str As String) = (1, "aaa")


    Public Class teat

        Sub New(Value As Integer, Str As String)

        End Sub

    End Class





End Class

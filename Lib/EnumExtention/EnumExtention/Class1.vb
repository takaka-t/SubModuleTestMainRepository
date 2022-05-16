'Imports System.Reflection
'Imports System.Runtime.CompilerServices

'''' <summary>
'''' Enum用Attribute:文字列の値
'''' </summary>
'<AttributeUsage(AttributeTargets.Field, AllowMultiple:=False, Inherited:=False)>
'Public Class EnumStringValue : Inherits Attribute
'    Public ReadOnly value As String
'    Sub New(value As String)
'        Me.value = value
'    End Sub
'End Class

'''' <summary>
'''' 試験的に運用(ProductMasterSearchFormで試用)
'''' Enumの各フィールドに文字列を持ちたい
'''' 自作属性EnumStringValueを利用して実装
'''' </summary>
'Public Module EnumExtension

'    ''' <summary>
'    ''' <para>EnumStringValue属性に設定した文字列を取得する</para>
'    ''' <para>例: TestEnum.A.StringValue</para>
'    ''' </summary>
'    ''' <param name="enumeration">列挙型のフィールド</param>
'    ''' <returns>未設定の場合は空文字</returns>
'    <Extension()>
'    Public Function StringValue(enumeration As [Enum]) As String
'        '指定しているフィールド取得
'        Dim field = enumeration.GetType().GetField(enumeration.ToString)
'        Return GetStringValue(field)
'    End Function



'    ''' <summary>
'    ''' <para>Combobox等のDataSource用</para>
'    ''' <para>匿名クラス{Value,StringValue}のリストを返す(仮)</para>
'    ''' <para>例: New TestEnum().GetItems</para>
'    ''' </summary>
'    ''' <param name="enumeration"></param>
'    ''' <returns></returns>
'    <Extension()>
'    <Obsolete("仮実装のため使用不可")>
'    Public Function GetItems(enumeration As [Enum]) As IEnumerable(Of (Value As Integer, String))
'        '現在対象Enumのフィールドをすべて取得
'        Dim fields = enumeration.GetType.GetFields

'        '各フィールドから戻り値用リスト作成
'        Dim list As New List(Of SelectItem(Of Object))
'        For Each field In fields

'            '0番目にIntegerなどの型指定情報がはいってくるためスルー
'            If field Is fields.First Then Continue For

'            'リストに情報追加
'            'list.Add(New With {Key .Value = field.GetRawConstantValue, .StringValue = GetStringValue(field)})
'            list.Add(New SelectItem(Of Object)(field.GetRawConstantValue, GetStringValue(field)))
'        Next

'        Return list
'    End Function

'    ''' <summary>
'    ''' 対象FieldのEnumStringValue属性から文字列を取得する
'    ''' </summary>
'    ''' <param name="field"></param>
'    ''' <returns>未設定の場合は空文字</returns>
'    Private Function GetStringValue(field As FieldInfo) As String
'        'EnumStringValue属性を取得する
'        Dim attribute = field.GetCustomAttributesData().SingleOrDefault(Function(x) x.AttributeType Is GetType(EnumStringValue))
'        Dim a As ValueType
'        If attribute Is Nothing Then
'            Return ""
'        Else
'            '属性のAllowMultipleによっては複数指定できる可能性があるため、リストでしか取得できないと思われる
'            'EnumStringValue属性はAllowMultiple = False のため、必ず1件のみ
'            Return attribute.ConstructorArguments.Single.Value.ToString
'        End If
'    End Function


'End Module





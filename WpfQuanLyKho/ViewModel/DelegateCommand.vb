Imports System
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Threading.Tasks
Imports System.Windows.Input

Namespace VTNCoLtd.Mvvm.Commands
    Public Class DelegateCommand(Of T)
        Inherits DelegateCommandBase

        Public Sub New(ByVal executeMethod As Action(Of T))
            Me.New(executeMethod, Function(o) True)
        End Sub

        Public Sub New(ByVal executeMethod As Action(Of T), ByVal canExecuteMethod As Func(Of T, Boolean))
            MyBase.New(Function(o) executeMethod(CType(o, T)), Function(o) canExecuteMethod(CType(o, T)))
            If executeMethod Is Nothing OrElse canExecuteMethod Is Nothing Then Throw New ArgumentNullException(NameOf(executeMethod))
            Dim genericTypeInfo = GetType(T).GetTypeInfo()

            If genericTypeInfo.IsValueType Then
                If Not genericTypeInfo.IsGenericType OrElse Not GetType(Nullable(Of)).GetTypeInfo().IsAssignableFrom(genericTypeInfo.GetGenericTypeDefinition().GetTypeInfo()) Then Throw New InvalidCastException()
            End If
        End Sub

        Protected Sub New(ByVal executeMethod As Func(Of T, Task))
            Me.New(executeMethod, Function(o) True)
        End Sub

        Protected Sub New(ByVal executeMethod As Func(Of T, Task), ByVal canExecuteMethod As Func(Of T, Boolean))
            MyBase.New(Function(o) executeMethod(CType(o, T)), Function(o) canExecuteMethod(CType(o, T)))
            If executeMethod Is Nothing OrElse canExecuteMethod Is Nothing Then Throw New ArgumentNullException(NameOf(executeMethod))
        End Sub

        Public Function ObservesProperty(Of TP)(ByVal propertyExpression As Expression(Of Func(Of TP))) As DelegateCommand(Of T)
            ObservesPropertyInternal(propertyExpression)
            Return Me
        End Function

        Public Function ObservesCanExecute(ByVal canExecuteExpression As Expression(Of Func(Of Object, Boolean))) As DelegateCommand(Of T)
            ObservesCanExecuteInternal(canExecuteExpression)
            Return Me
        End Function

        <Obsolete("This async command break synchronous scenarios. We will be removing this from the next update in Prism 6.3.")>
        Public Shared Function FromAsyncHandler(ByVal executeMethod As Func(Of T, Task)) As DelegateCommand(Of T)
            Return New DelegateCommand(Of T)(executeMethod)
        End Function

        <Obsolete("This async command break synchronous scenarios. We will be removing this from the next update in Prism 6.3.")>
        Public Shared Function FromAsyncHandler(ByVal executeMethod As Func(Of T, Task), ByVal canExecuteMethod As Func(Of T, Boolean)) As DelegateCommand(Of T)
            Return New DelegateCommand(Of T)(executeMethod, canExecuteMethod)
        End Function

        Public Overridable Function CanExecute(ByVal parameter As T) As Boolean
            Return MyBase.CanExecute(parameter)
        End Function

        Public Overridable Function Execute(ByVal parameter As T) As Task
            Return MyBase.Execute(parameter)
        End Function
    End Class

    Public Class DelegateCommand
        Inherits DelegateCommandBase

        Public Sub New(ByVal executeMethod As Action)
            Me.New(executeMethod, Function() True)
        End Sub

        Public Sub New(ByVal executeMethod As Action, ByVal canExecuteMethod As Func(Of Boolean))
            MyBase.New(Function(o) executeMethod(), Function(o) canExecuteMethod())
            If executeMethod Is Nothing OrElse canExecuteMethod Is Nothing Then Throw New ArgumentNullException(NameOf(executeMethod))
        End Sub

        Protected Sub New(ByVal executeMethod As Func(Of Task))
            Me.New(executeMethod, Function() True)
        End Sub

        Protected Sub New(ByVal executeMethod As Func(Of Task), ByVal canExecuteMethod As Func(Of Boolean))
            MyBase.New(Function(o) executeMethod(), Function(o) canExecuteMethod())
            If executeMethod Is Nothing OrElse canExecuteMethod Is Nothing Then Throw New ArgumentNullException(NameOf(executeMethod))
        End Sub

        Public Function ObservesProperty(Of T)(ByVal propertyExpression As Expression(Of Func(Of T))) As DelegateCommand
            ObservesPropertyInternal(propertyExpression)
            Return Me
        End Function

        Public Function ObservesCanExecute(ByVal canExecuteExpression As Expression(Of Func(Of Object, Boolean))) As DelegateCommand
            ObservesCanExecuteInternal(canExecuteExpression)
            Return Me
        End Function

        <Obsolete("This async command break synchronous scenarios. We will be removing this from the next update in Prism 6.3.")>
        Public Shared Function FromAsyncHandler(ByVal executeMethod As Func(Of Task)) As DelegateCommand
            Return New DelegateCommand(executeMethod)
        End Function

        <Obsolete("This async command break synchronous scenarios. We will be removing this from the next update in Prism 6.3.")>
        Public Shared Function FromAsyncHandler(ByVal executeMethod As Func(Of Task), ByVal canExecuteMethod As Func(Of Boolean)) As DelegateCommand
            Return New DelegateCommand(executeMethod, canExecuteMethod)
        End Function

        Public Overridable Function Execute() As Task
            Return Execute(Nothing)
        End Function

        Public Overridable Function CanExecute() As Boolean
            Return CanExecute(Nothing)
        End Function

                ''' Cannot convert ConversionOperatorDeclarationSyntax, CONVERSION ERROR: Conversion for ConversionOperatorDeclaration not implemented, please report this issue in 'public static implicit oper...' at character 12702
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.DefaultVisit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.Syntax.ConversionOperatorDeclarationSyntax.Accept[TResult](CSharpSyntaxVisitor`1 visitor)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingNodesVisitor.DefaultVisit(SyntaxNode node)
''' 
''' Input: 
''' 
'''         public static implicit operator DelegateCommand(DelegateCommand<string> v)
'''         {
'''             throw new NotImplementedException();
'''         }
''' 
''' 
    End Class
End Namespace

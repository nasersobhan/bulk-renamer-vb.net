Imports System.IO

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not pathtxt.Text = "" Then

            My.Settings.xpath = pathtxt.Text
            My.Settings.Save()

            Dim sourcePath As String = pathtxt.Text



            Dim searchPattern As String = "*.*"
            Dim i As Integer = 0
            resulttxt.Text = "Start Renameing..."
            Dim files As Array = Directory.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories)
            pbar1.Visible = True
            ' Set Minimum to 1 to represent the first file being copied.
            pbar1.Minimum = 1
            ' Set Maximum to the total number of files to copy.
            pbar1.Maximum = files.Length
            ' Set the initial value of the ProgressBar.
            pbar1.Value = 1
            ' Set the Step property to a value of 1 to represent each file being copied.
            pbar1.Step = 1

            '   For Each folderName As String In Directory.GetDirectories(sourcePath, searchPattern, SearchOption.AllDirectories)


            For Each fileName As String In files





                Dim basenamex As String = Path.GetFileName(fileName)
                ' Dim ext As String = Path.GetExtension(fileName)



                File.Move(Path.Combine(sourcePath, fileName), Path.Combine(sourcePath, fileName.Replace(basenamex, renameer(basenamex))))


                resulttxt.Text = resulttxt.Text & vbCrLf & "Renamed: {" & basenamex & "} to {" & renameer(basenamex) & "}"

                i += 1
                pbar1.PerformStep()
            Next
            resulttxt.Text = resulttxt.Text & vbCrLf & "Stop task..."

            '   Next
        Else
            MsgBox("Please Insert path")
            pathtxt.Focus()

        End If

    End Sub


    Function renameer(ByVal fname As String)
        Dim newfname As String = fname
        ' For Each st As String In ListBox1.SelectedItems
        'newfname = newfname.Replace("", "-")
        ' Next
       
        If toLowerchk.Checked Then
            newfname = newfname.ToLower()
        End If

        For l_index As Integer = 0 To ListBox1.Items.Count - 1
          
            Dim l_text As String = CStr(ListBox1.Items(l_index))
            newfname = newfname.Replace(l_text, "-")

        Next



        Return newfname
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.chars = " "


        For l_index As Integer = 0 To ListBox1.Items.Count - 1

            Dim l_text As String = CStr(ListBox1.Items(l_index))

            My.Settings.chars = My.Settings.chars & "-" & l_text
            My.Settings.Save()
        Next
    End Sub

 

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pathtxt.Text = My.Settings.xpath
     

        Dim strarr() As String
        strarr = My.Settings.chars.Split("-")

        For Each s As String In strarr.Distinct()
            ListBox1.Items.Add(s)
        Next

        'addchar.Text = My.Settings.chars

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FolderBrowserDialog1.ShowDialog()
        pathtxt.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not addchar.Text = "" Then
            ListBox1.Items.Add(addchar.Text)
        Else
            MsgBox("type something")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click, Label3.Click

    End Sub
End Class

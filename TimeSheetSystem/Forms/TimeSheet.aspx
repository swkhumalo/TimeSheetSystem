<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSheet.aspx.cs" enableEventValidation="true" Inherits="TimeSheetSystem.Forms.TimeSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="icon" href="../img/Logo1160IDnr1.png"/>
	<meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

	<title>TimeSheet System |TimeSheet</title>

	<!-- Bootstrap core CSS -->
	<link href="../css/bootstrap.min.css" type="text/css" rel="stylesheet"/>
	<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
	<link href="../css/style.css" type="text/css" rel="stylesheet"/>

    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            left: 0px;
            top: 0px;
            padding-left: .9375rem;
            padding-right: .9375rem;
        }
    </style>

</head>
<body>
<form id="form1" runat="server">

			   
	 <!-- Navigation -->
	 <nav class="navbar navbar-default">
			<div class="container">
		<div class="navbar-header">
		  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
			<span class="sr-only">Toggle navigation</span>
			<span class="icon-bar"></span>
			<span class="icon-bar"></span>
			<span class="icon-bar"></span>
		  </button>
		  <a class="navbar-brand" href="Dashboard.aspx">TimeSheet Administrator</a>
		</div>
         <div id="navbar" class="collapse navbar-collapse">
		  <ul class="nav navbar-nav">
			<li><a href="Dashboard.aspx">Dashboard</a></li>
			<li class="active"><a href="TimeSheet.aspx">Time Sheet</a></li>
			<li><a href="Employees.aspx">Employees</a></li>
		  </ul>
		  <ul class="nav navbar-nav navbar-right">
			<li class="active"><a href="#">
				<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a></li>
			<li><a href="Signin.aspx">Logout</a></li>
		  </ul>
		</div><!--/.nav-collapse -->
	  </div>
		</nav>

	 <!-- Header -->
	 <header id="header">
  <div class="container">
	<div class="row">
	  <div class="col-md-10">
		  <h1><span class="glyphicon glyphicon-home" aria-hidden="true"></span> Time Sheet |<small>TimeSheet System</small></h1>
	  </div>
	  <div class="col-md-2">
  
	  </div>
	</div>
  </div>
</header>

	 <!-- Section Breadcrumb -->
	 <section id="breadcrumb">
		  <div class="container">
			<ol class="breadcrumb">
			  <li><a href="Dashboard.aspx">Dashboard</a></li>
			  <li class="active">TimeSheet</li>
			</ol>
		  </div>
		</section>

	 <!-- Navigation -->
	 <section id="main">
  <div class="container">
	<div class="row">

	  <div class="auto-style1">

		<!--Website Overview -->
		<div class="panel panel-default">
		 <div class="panel-heading main-color-bg">
		   <h3 class="panel-title">Daily Time Sheet&nbsp;&nbsp;</h3>
		 </div>
		 <div class="panel-body">
		   <div class="row">
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBTimeSheetConnectionStr %>" SelectCommand="SELECT Employees.EmployeeNo, Employees.LastName, TimeSheet.TimeIn, TimeSheet.TimeOut, TimeSheet.BreakOut, TimeSheet.BreakIn, TimeSheet.HoursWorked, TimeSheet.Monday, TimeSheet.Tuesday, TimeSheet.Wednesday, TimeSheet.Thursday, TimeSheet.Friday, TimeSheet.Wages 
FROM TimeSheet 
INNER JOIN Employees 
ON 
TimeSheet.EmployeeNo = Employees.EmployeeNo"></asp:SqlDataSource>

				<asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_IndexChanged" DataKeyNames="EmployeeNo" DataSourceID="SqlDataSource1" >
					 <AlternatingRowStyle BackColor="White" />
					 <Columns>
                         <asp:ButtonField ButtonType="Button" CommandName="Sel" Text="Edit" >
						 <ControlStyle CssClass="btn btn-default" />
						 </asp:ButtonField>
						 <asp:TemplateField HeaderText="EmployeeNo" SortExpression="EmployeeNo">
                             <EditItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeeNo") %>'></asp:Label>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeNo") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                         <asp:BoundField DataField="TimeIn" HeaderText="TimeIn" SortExpression="TimeIn" />
                         <asp:BoundField DataField="TimeOut" HeaderText="TimeOut" SortExpression="TimeOut" />
                         <asp:BoundField DataField="BreakOut" HeaderText="BreakOut" SortExpression="BreakOut" />
                         <asp:BoundField DataField="BreakIn" HeaderText="BreakIn" SortExpression="BreakIn" />
                         <asp:BoundField DataField="HoursWorked" HeaderText="HoursWorked" SortExpression="HoursWorked" />
                         <asp:BoundField DataField="Monday" HeaderText="Monday" SortExpression="Monday" />
                         <asp:BoundField DataField="Tuesday" HeaderText="Tuesday" SortExpression="Tuesday" />
                         <asp:BoundField DataField="Wednesday" HeaderText="Wednesday" SortExpression="Wednesday" />
                         <asp:BoundField DataField="Thursday" HeaderText="Thursday" SortExpression="Thursday" />
                         <asp:BoundField DataField="Friday" HeaderText="Friday" SortExpression="Friday" />




					 </Columns>
					 <EditRowStyle BackColor="#2461BF" />
					 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					 <RowStyle BackColor="#EFF3FB" />
					 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					 <SortedAscendingCellStyle BackColor="#F5F7FB" />
					 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
					 <SortedDescendingCellStyle BackColor="#E9EBEF" />
					 <SortedDescendingHeaderStyle BackColor="#4870BE" />
				 </asp:GridView>

			 </div>
		   </div>
		 </div>
	   </div>


	  </div>
	</div>
  </div>
</section>

	 <!-- Footer -->
	 <footer id="footer">
			<p>Copyright TimeSheet System &copy; 2018</p>
		</footer>

	 <!-- Bootstrap core JavaScript
	 ================================================== -->
	 <!-- Placed at the end of the document so the pages load faster -->
	 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	 <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
	 <script src="js/bootstrap.min.js"></script>
	 <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
	 <script src="js/ie10-viewport-bug-workaround.js"></script>


	</form>
</body>
</html>

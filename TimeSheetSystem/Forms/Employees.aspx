<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="TimeSheetSystem.Forms.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="icon" href="../img/Logo1160IDnr1.png"/>
	<meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

	<title>TimeSheet System |Employees</title>

	<!-- Bootstrap core CSS -->
	<link href="../css/bootstrap.min.css" type="text/css" rel="stylesheet"/>
	<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
	<link href="../css/style.css" type="text/css" rel="stylesheet"/>

	<style type="text/css">
		.auto-style1 {
			display: block;
			width: 88%;
			height: 34px;
			font-size: 14px;
			line-height: 1.42857143;
			color: #555;
			border-radius: 4px;
			-webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
			box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
			-webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
			-o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
			transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
			border: 1px solid #ccc;
			padding: 6px 12px;
			background-color: #fff;
			background-image: none;
		}
	</style>

</head>
<body>
		<form id="form1" runat="server">
	<div>
	
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
			<li><a href="TimeSheet.aspx">Time Sheet</a></li>
			<li class="active"><a href="Employees.aspx">Employees</a></li>

		  </ul>
		  <ul class="nav navbar-nav navbar-right">
			<li class="active"><a href="#">
				<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></a></li>
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
		  <h1><span class="glyphicon glyphicon-home" aria-hidden="true"></span> Employees |<small>TimeSheet System</small></h1>
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
			  <li class="active">Employees</li>
			</ol>
		  </div>
		</section>

		<!-- Navigation -->
		<section id="main">
  <div class="container">
	<div class="row">
	  <div class="col-md-3">

		<div class="list-group">
		  <a href="#" class="list-group-item active">
			<span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Dashboard
		  </a>

		  <a href="Employees.aspx" class="list-group-item"><span class="glyphicon glyphicon-user" aria-hidden="true"></span> Employees 
			  <span class="badge">
					<asp:Label ID="Employees1" runat="server" Text="Label"></asp:Label>
			  </span>
		  </a>
		  <a href="TimeSheet.aspx" class="list-group-item"><span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> Time Sheet 
		  </a>
				
			
		  <a href="AddEmployees.aspx" class="list-group-item"><span class="glyphicon glyphicon-plus-sign" aria-hidden="true"></span> Add New Employee
		  </a>
		</div>

		<div class="well">
		  <h4>Disk Space Used</h4>
		  <div class="progress">
			<div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: 60%;">
			  60%
			</div>
		  </div>
		  <h4>Bandwidth</h4>
		  <div class="progress">
			<div class="progress-bar" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 40%;">
			  40%
			</div>
		  </div>
		</div>

	  </div>
	  <div class="col-md-9">

   <!--Website Overview -->
		<div class="panel panel-default">
		 <div class="panel-heading main-color-bg">
		   <h3 class="panel-title">Employee's Overview&nbsp;
			   </h3>
		 </div>
		 <div class="panel-body">
		   <div class="row">
			 <div class="col-md-12">
			     
				 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBTimeSheetConnectionStr %>" SelectCommand="SELECT * FROM [Employees] ORDER BY [EmployeeNo]" DeleteCommand="DELETE FROM Employees FROM Employees INNER JOIN TimeSheet ON Employees.EmployeeNo = TimeSheet.EmployeeNo WHERE (Employees.EmployeeNo = @EmployeeNo)">
                     <DeleteParameters>
                         <asp:Parameter Name="EmployeeNo" />
                     </DeleteParameters>
                 </asp:SqlDataSource>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeNo" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>

                         <asp:templatefield HeaderText="Select">
                            <itemtemplate>
                        <asp:checkbox ID="cbSelect" 

                        CssClass="gridCB" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>

                          <asp:ButtonField ButtonType="Button" CommandName="Sel" Text="Edit" >
						 <ControlStyle CssClass="btn btn-default" />
						 </asp:ButtonField>
						 <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" >
						 <ControlStyle CssClass="btn btn-danger" />
						 </asp:ButtonField>
                          <asp:TemplateField HeaderText="EmployeeNo" SortExpression="EmployeeNo">
                              <EditItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeeNo") %>'></asp:Label>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeNo") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                         <asp:BoundField DataField="Initials" HeaderText="Initials" SortExpression="Initials" />
                         <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                         <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                         <asp:BoundField DataField="IdentityNo" HeaderText="IdentityNo" SortExpression="IdentityNo" />
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


	</div>
	</form>
</body>
</html>

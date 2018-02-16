<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="true" CodeBehind="EditTimeSheet.aspx.cs" Inherits="TimeSheetSystem.Forms.EditTimeSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="icon" href="../img/Logo1160IDnr1.png"/>
	<meta charset="utf-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

	<title>TimeSheet System |Edit TimeSheet</title>

	<!-- Bootstrap core CSS -->
	<link href="../css/bootstrap.min.css" type="text/css" rel="stylesheet"/>
	<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
	<link href="../css/style.css" type="text/css" rel="stylesheet"/>

	<style type="text/css">
		.auto-style2 {
			position: relative;
			min-height: 1px;
			float: left;
			width: 83.33333333%;
			left: 0px;
			top: -1px;
			padding-left: 15px;
			padding-right: 15px;
		}
	    .auto-style3 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            left: 0px;
            top: -1px;
            padding-left: 15px;
            padding-right: 15px;
            height: 223px;
        }
        .auto-style4 {
            width: 584px;
        }
	    .auto-style5 {
            width: 415px;
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
	  <div class="auto-style2">
		  <h1><span class="glyphicon glyphicon-home" aria-hidden="true"></span> Edit Time Sheet |<small>TimeSheet System </small></h1>
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
	  <li>Dashboard</li>
	  <li class="active">Edit TimeSheet</li>
	</ol>
  </div>
</section>

		<!-- Navigation -->
		<section id="main">
  <div class="container">
	<div class="row">
	  <div class="col-md-3">

          <div class="list-group">
		  <a class="list-group-item active">
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
		   <h3 class="panel-title">Manage Time Sheet&nbsp;</h3>
		 </div>
		 <div class="panel-body">
		   <div class="row">
			 <div class="col-md-12">




				 <table class="auto-style3">
					 <tr>
						 <td class="auto-style4">
				            <div class="auto-style1">
					            <label>Employee No</label>
					            <asp:Textbox class="form-control" runat="server" type="" required="" placeholder="EmployeeNo" ID="txtEmployeeNo" Width="320px" ReadOnly="True"></asp:Textbox>
			
					            <label>Time-In</label>
					            <asp:Textbox class="form-control" runat="server" type="" required="" ID="txtTimeIn" Width="320px" TextMode="Time"></asp:Textbox>
				
					            <label>Break-In</label>
					            <asp:Textbox class="form-control" runat="server" type="" required="" ID="txtBreakIn" Width="320px" TextMode="Time"></asp:Textbox>
				            </div>
				        </td>
						<td class="auto-style5">
					        <div class="auto-style1">
					            <label>Last Name</label> 
					            <asp:Textbox class="form-control" runat="server" type="" required="" placeholder="Last Name" ID="txtLastName" Width="320px" ReadOnly="True"></asp:Textbox>
				
					            <label>Time-Out</label> 
					            <asp:Textbox class="form-control" runat="server" type="" required="" ID="txtTimeOut" Width="320px" TextMode="Time">0</asp:Textbox>
				
					            <label>Break-Out</label>
				               <asp:Textbox class="form-control" runat="server" type="" ID="txtBreakOut" Width="320px" TextMode="Time"></asp:Textbox>
				            </div>
						</td>
					 </tr>
                     <tr>
                         
                         <td>&nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="2"><asp:RadioButton ID="RadioButton1" AutoPostBack="true" runat="server" Text="Monday" OnCheckedChanged="RadioButton1_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:RadioButton ID="RadioButton2" AutoPostBack="true" runat="server" Text="Tuesday" OnCheckedChanged="RadioButton2_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:RadioButton ID="RadioButton3" AutoPostBack="true" runat="server" Text="Wednesday" OnCheckedChanged="RadioButton3_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                              <asp:RadioButton ID="RadioButton4" AutoPostBack="true" runat="server" Text="Thursday" OnCheckedChanged="RadioButton4_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:RadioButton ID="RadioButton5" AutoPostBack="true" runat="server" Text="Friday" OnCheckedChanged="RadioButton5_CheckedChanged" />
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000080">&nbsp;&nbsp;</td>
                     </tr>
                     
				 </table>
				 
			     <br />
				 
			 <br />
					 <asp:Button CssClass="btn btn-primary" type="button" ID="btnTotalWage" runat="server" Text="TOTAL WAGE" Width="260px" OnClick="btnTotalWage_Click" />        

				 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					 <asp:Button CssClass="btn btn-default" type="button" ID="btnClear" runat="server" Text="CLEAR"  Width="140px" BackColor="#999999" OnClick="btnClear_Click"/>    
				 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					 <asp:Button CssClass="btn btn-default" type="button" ID="btnExit" runat="server" Text="EXIT"  Width="140px" BackColor="#999999" OnClick="btnExit_Click"/>    
				 <br />
			 <br />
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

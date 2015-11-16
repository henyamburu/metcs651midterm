<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
	<meta charset="utf-8"/>
	<title>Cipher</title>
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
	<script src="assets/js/bootstrap.min.js"></script>
	<script src="assets/js/scripts.js"></script>
	<link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
	<!--[if lt IE 9]>
		<script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
	<link href="assets/css/styles.css" rel="stylesheet"/>
    <script type="text/javascript">
        function CallService() {
            var encodedMsg = $('textarea.form-control').val();
            var analysisType = $('select.form-control').val();
            if ($.trim(encodedMsg) != '') {
                $.ajax({
                    type: "GET", //GET or POST or PUT or DELETE verb
                    url: '/Service.svc/GetMessage?encodedMessage="' + encodedMsg + '"&method="' + analysisType + '"', // Location of the service
                    data: "json", //Data sent to server
                    contentType: "application/json; charset=utf-8", // content type sent to server
                    dataType: 'json', //Expected data format from server
                    processdata: true, //True or False
                    success: ServiceSucceeded,//On Successfull service call
                    error: ServiceFailed// When Service call fails
                });
            }
        }

        function  ServiceSucceeded(result) {
            //console.log(result);
            $("#previewMessage").html(result.d);
        }

        function ServiceFailed(result) {
            console.log('Service call failed: ' + result.status + ' ' + result.statusText);
        }

        $(function () {
            $('button.btn').on('click', function () {
                CallService();
            });
            $('textarea.form-control').on('keyup', function () {
                CallService();
            });
            $('select.form-control').on('change', function () {
                CallService();
            });
        });
    </script>
</head>
    <body>
	<nav class="navbar navbar-fixed-top header">
		<div class="col-md-12">
			<div class="navbar-header">			  
			  <a href="#" class="navbar-brand">Cipher</a>		  
			</div>
        </div>	
	</nav>
	<!--main-->
	<div class="container-fluid" id="main">
	   <div class="row">
	   <div class="col-md-6 col-sm-6">
			<div class="well"> 
				 <form class="form-horizontal" role="form">
				  <h4>Scrambled Message</h4>
                    <div class="control-group">
				        <label>Select Strategy Method</label>
				    <div class="controls">
					   <select class="form-control">
                           <option value="monogram">Letter Frequency</option>
                           <option value="bigram">Bigram Frequency</option>                                    
                           <option value="trigram">Triagram Frequency</option>
                           <option value="cryptogram">Gold Bug</option>
                        </select>
				  </div>
				</div>  
				   <div class="form-group" style="padding:14px;">
					<textarea class="form-control" placeholder="Copy/paste or type scrambled message"></textarea>
				  </div>
                     <div class="control-group">
                        <div class="controls">
                            <button class="btn btn-success pull-right" type="button">Scramble</button>
                            <div class="clearfix"></div>
                        </div>
                    </div>   
				</form>
			</div>
		</div>
		<div class="col-md-6 col-sm-6">
			 <div class="panel panel-default">
			   <div class="panel-heading">
                   <h4>Unscrambled Message</h4>
                </div>
				<div class="panel-body">
                    <div>
				        <p id="previewMessage"></p>
				        <div class="clearfix"></div>
                    </div>
                    <hr>
				</div>
			 </div>
		</div>
	  </div><!--/row-->
	  
	  <hr>
	</div><!--/main-->		
	</body>
</html>

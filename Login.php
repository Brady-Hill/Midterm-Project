<?php
//Create variables to hold parameters to make a connection to database
	$servername = "localhost";
	$serverusername = "id11293881_bradyhill86";
	$serverpassword = 'password';
	$dbName = "id11293881_userlogin";

	//Get Info from Unity into variables to pass into database from this PHP file
	$username = $_POST{"usernamePost"};
	$password = $_POST{"passwordPost"};

	//Start Connection
	$conn = new mysqli($servername, $serverusername, $serverpassword, $dbName);

	//Check and see if connection is successful
	if(!$conn)
	{
	die("Connection Failure". mysqli_connect_error());
	}

	$sql = "SELECT Password FROM logininfo WHERE Name = '" .$username."' ";

	$result = mysqli_query($conn,$sql);

	if(mysqli_num_rows($result) > 0)
	{
		while($row = $result->fetch_assoc())
		{
			if($row["Password"] == $password)
			{
				echo $row["Wins"]."|".$row["Losses"];
			}
			else
				echo "Password";
		}
	}
	else echo "Username";

	$conn->close();
?>
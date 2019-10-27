<?php
//Create variables to hold parameters to make a connection to database
	$servername = "localhost";
	$serverusername = "id11293881_bradyhill86";
	$serverpassword = 'password';
	$dbName = "id11293881_userlogin";

	//Get Info from Unity into variables to pass into database from this PHP file
	$username = $_POST{"usernamePost"};
	$password = $_POST{"passwordPost"};
    $wins = $_POST{"userWins"};
    $losses = $_POST{"userLosses"};

	//Start Connection
	$conn = new mysqli($servername, $serverusername, $serverpassword, $dbName);

	//Check and see if connection is successful
	if(!$conn)
	{
	die("Connection Failure". mysqli_connect_error());
	}

	$sql = "SELECT ID, Password, Wins, Losses FROM logininfo WHERE Name = '" .$username."' ";

	$result = $conn->query($sql);

	if(mysqli_num_rows($result) > 0)
	{
        $userID = $result->fetch_assoc()["ID"];

        $sql2 = "UPDATE `logininfo` SET `Wins`= Wins + '".$wins."',`Losses`= Losses + '".$losses."' WHERE ID = '" .$userID."'";
        $conn->query($sql2);
	}
	else echo "Error";


	$conn->close();
?><?php

?>
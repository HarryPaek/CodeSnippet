public class MyException: Exception
{
}

public class MyClass: IDisposable
{
}

public void MyMethod()
{
	MyClass myClass = null;
	
	try
	{
		myClass = new MyClass();
	    
		// To Do Something
	}
	catch(Exception ex)
	{
	    throw;
	}
	catch(MyException myex)
	{
	    throw myex;
	}
	finally
	{
		// To Do Something
		
	    myClass = null;
	}
}


public void MyMethod()
{
	MyClass myClass = null;
	
	try
	{
		myClass = new MyClass();
	    
		// To Do Something
	}
	catch(Exception ex)
	{
	}
	finally
	{
		// To Do Something
	    myClass = null;
	}
}

public void MyMethod()
{
	MyClass myClass = null;
	
	try
	{
		myClass = new MyClass();
	    
		// To Do Something
	}
	catch(Exception ex)
	{
	}
	finally
	{
		// To Do Something
	}
	
	myClass = null;
}

public void MyMethod()
{
	MyClass myClass = null;
	
	try
	{
		using(myClass = new MyClass())
		{
			// To Do Something
		}
	}
	catch(Exception ex)
	{
	}
	finally
	{
		// To Do Something
	}
}


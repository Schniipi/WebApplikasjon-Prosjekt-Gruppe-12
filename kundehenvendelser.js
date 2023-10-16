function submitForm() {
    var name = document.getElementById('name').value;
    var email = document.getElementById('email').value;
    var message = document.getElementById('message').value;
  
    var responseDiv = document.getElementById('response');
  
    // You can add additional logic here to handle the form, such as AJAX requests to send data to the server.
  
    // Simple response message for demonstration purposes:
    responseDiv.innerHTML = `<p>Takk, ${name}! Vi har mottatt din henvendelse.</p>`;
  }
  

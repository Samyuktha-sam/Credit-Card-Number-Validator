document.getElementById('card-form').addEventListener('submit', function(event) {
  event.preventDefault(); // Prevent the form from submitting the traditional way

  const cardNumber = document.getElementById('card-number').value;
  const resultDiv = document.getElementById('result');
  resultDiv.innerHTML = "Loading...";
  resultDiv.className = "result loading";

  fetch('http://localhost:5038/api/Validation', {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json'
      },
      body: JSON.stringify({ creditCardNumber: cardNumber })
  })
  .then(response => {
      if (!response.ok) {
          throw new Error('Network response was not ok');
      }
      return response.json();
  })
  .then(data => {
      if (data.isValid) {
          resultDiv.innerHTML = `✔ Valid Card Number<br><span class="error-message">${data.message}</span>`;
          resultDiv.className = "result valid";
      } else {
          resultDiv.innerHTML = `✘ Invalid Card Number<br><span class="error-message">${data.message}</span>`;
          resultDiv.className = "result invalid";
      }
  })
  .catch(error => {
      console.error('Error:', error);
      resultDiv.innerHTML = 'An error occurred while validating the credit card.';
      resultDiv.className = "result error";
  });
});

document.getElementById('reset-button').addEventListener('click', function() {
  document.getElementById('card-number').value = ''; 
  const resultDiv = document.getElementById('result');
  resultDiv.innerHTML = ''; 
  resultDiv.className = 'result'; 
});


$(function() {
    $('#apiLoginForm').on("submit", function(e) {
      e.preventDefault();

      var bearerToken = login();

      if (bearerToken == '')
      {
          alert('Invalid credentials');
          return;
      }
  
      var data = getData(bearerToken);
     
      return false;
    });
  });

function login()
{
    var params = {
        email: document.querySelector('#Email').value,
        password: document.querySelector('#Password').value
    }

    const xhr = new XMLHttpRequest()
    xhr.open('POST', 'https://localhost:7070/login', false)
    xhr.setRequestHeader("Content-type", "application/json")
    xhr.send(JSON.stringify(params))

    return xhr.responseText
}

function getData(bearerToken)
{
    const xhr = new XMLHttpRequest()
    xhr.open('GET', 'https://localhost:7070/SurveyStats', false)
    xhr.setRequestHeader("Content-type", "application/json")
    xhr.setRequestHeader('Authorization', 'Bearer ' + bearerToken);
    xhr.send();

    return xhr.responseText
}
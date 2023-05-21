import logo from './logo.svg';
import { useState } from "react";
import axios from "axios"
import './App.css';
import { useNavigate } from "react-router-dom";

function App() {
    const navigate = useNavigate();
  const [name, setName] = useState("");
  const [address, setEmail] = useState("");
  const [message, setMessage] = useState("");

  let handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const params = JSON.stringify({
        name: name,
        address: address,
        });
      let res = await axios.post('https://localhost:7030/api/merchants', params, {
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        }

      }).then(function (response) {
        console.log(response);
          navigate("/dashboard", { state: { data: response.data } });
        
    }).catch(function (error) {
        console.log(error);
    });
      let resJson = await res.json();
      if (res.status === 200) {
        setName("");
        setEmail("");
        setMessage("User created successfully");
      } else {
        setMessage("Some error occured");
      }
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="App">
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={name}
          placeholder="Name"
          onChange={(e) => setName(e.target.value)}
        />
        <input
          type="text"
          value={address}
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
        />

        <button type="submit">Create</button>

        <div className="message">{message ? <p>{message}</p> : null}</div>
      </form>
    </div>
  );
}

export default App;

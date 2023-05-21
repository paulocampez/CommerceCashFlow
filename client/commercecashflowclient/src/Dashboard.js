import { useLocation } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";
function Dashboard() {
    const location = useLocation();
    const [list, setList] = useState([]);
    const [amount, setAmount] = useState("");
    const [transactionCategory, setCategory] = useState(0);
    useEffect(() => {
        axios.get('https://localhost:7030/api/transactions', {params: {merchantId: location.state.data}}).then((response) => {
            setList(response.data);
        });
    }, []);
    let handleSubmit = async (e) => {
        e.preventDefault();
        try {
          const params = JSON.stringify({
            "amount": parseFloat(amount),
            "transactionCategory": parseInt(transactionCategory),
            "merchantId": location.state.data
            });
          let res = await axios.post('https://localhost:7030/api/transactions', params, {
            headers: {
              'Content-Type': 'application/json',
              'Accept': 'application/json'
            }
    
          }).then(function (response) {
            console.log(response);
            
        }).catch(function (error) {
            console.log(error);
        });
          let resJson = await res.json();
          if (res.status === 200) {
            setAmount(0);
            setCategory(0);
            console.log("User created successfully");
          } else {
            console.log("Some error occured");
          }
        } catch (err) {
          console.log(err);
        }
      };



        console.log(location.state.data);
          return (
                 <div className="App">
            <form onSubmit={handleSubmit}>
            <select value={transactionCategory} onChange={(e) => setCategory(e.target.value)}>
                <option value="0">Credito</option>
                <option value="1">Debito</option>
            </select>
              <input
                type="decimal"
                value={amount}
                placeholder="Amount"
                onChange={(e) => setAmount(e.target.value)}
              />
      
              <button type="submit">Create Transaction</button>
      
              {/* <div className="message">{message ? <p>{message}</p> : null}</div> */}
            </form>
            <hr></hr>

            {list.map(( list, index ) => {
          return (
            <tr key={index}>
              <td>{list.id}</td>
              <td>{list.title}</td>
              <td>{list.price}</td>
            </tr>
          );
        })}
          </div>
          );

}
export default Dashboard;

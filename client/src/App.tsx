import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react"


function App() {
  const [tickets, setTickets] = useState<Ticket[]>([]);

  useEffect(() => {
      axios.get<Ticket[]>('https://localhost:5001/api/tickets')
        .then(response => setTickets(response.data))
  }, [])

  return (
    <>
      <Typography variant='h4'>Cinema</Typography>
      <List>
        {tickets.map((ticket) =>(
          <ListItem key={ticket.id}>
            <ListItemText>{ticket.price} PLN</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default App

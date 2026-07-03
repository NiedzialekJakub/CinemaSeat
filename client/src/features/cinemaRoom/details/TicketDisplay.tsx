import { Avatar, } from '@mui/material'

type Props = {
    ticket: Ticket
}

export default function TicketDisplay({ticket}: Props) {

    let color = '#061031';

    if(ticket.sector === 2){
        color = '#f76c10'
    }
    if(ticket.sector === 3){
        color = '#240315'
    }
    if(ticket.sector === 4){
        color = '#94bbec'
    }
    if(ticket.sector === 5){
        color = '#6b0dd6'
    }

  return (
    <Avatar sx={{bgcolor: color, color: 'white'}}>
        {ticket.seatNumber}
    </Avatar>
  )
}

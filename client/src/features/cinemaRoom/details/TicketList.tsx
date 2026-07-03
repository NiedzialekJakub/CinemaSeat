import { Box } from "@mui/material"
import TicketDisplay from "./TicketDisplay"

type Props = {
    tickets: Ticket[]
}



export default function TicketList({tickets} : Props) {
    const sortedTickets = [...tickets].sort((a, b) => {
        if(a.row !== b.row){
            return a.row - b.row;
        }
        return a.seatNumber - b.seatNumber;
    });

    const rows: Ticket[][] = [];
    let currentRow: Ticket[] = [];

    sortedTickets.forEach((ticket, index) => {
        const prevTicket = sortedTickets[index - 1];

        const splitByCount = currentRow.length === 15;
        const splitBySector = prevTicket && ticket.row != prevTicket.row;

        if(splitByCount || splitBySector){
            rows.push(currentRow);
            currentRow = [];
        }

        currentRow.push(ticket);
    });

    if(currentRow.length > 0)
    {
        rows.push(currentRow);
    }

    return (
        <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2 }}>
            {rows.map((row, rowIndex) => (
                <Box 
                    key={rowIndex} 
                    sx={{ display: 'flex', flexDirection: 'row', gap: 1.5 }}
                >
                    {row.map(ticket => (
                        <TicketDisplay key={ticket.id} ticket={ticket} />
                    ))}
                </Box>
            ))}
        </Box>
    )
}

import { useParams } from "react-router"
import { useFilms } from "../../../lib/hooks/useFilms";
import { Box, Grid, Typography } from "@mui/material";
import { useTickets } from "../../../lib/hooks/useTickets";
import TicketList from "../details/TicketList";

export default function CinemaRommDashboard() {
    const {id} = useParams();
    const filmId = id ? parseInt(id, 10) : undefined;
    const {film, isLoading} = useFilms(filmId);
    const {tickets, isPending} = useTickets(filmId);

    if(isLoading || isPending) {
        return(
            <Box>
                <Typography sx={{color: 'white'}}>Loading..</Typography>
            </Box>
        );
    }

    if(!film) {
        return(
            <Box>
                <Typography sx={{color: 'white'}}>Film not found</Typography>
            </Box>
        );
    }

  return (
    <Grid>
        {isLoading || isPending ?(
            <Typography variant="h2" sx={{color: 'white'}}>Loading...</Typography>
        ) : (
            <Grid container sx={{gap: 20}}>
                <Typography variant="h2" sx={{color: 'white', fontWeight: 'bold'}}>Tickets</Typography>
                <Box sx={{pt: 20}}>
                    <TicketList tickets={tickets ?? []} />
                </Box>
            </Grid>
        )}

    </Grid>
  )
}

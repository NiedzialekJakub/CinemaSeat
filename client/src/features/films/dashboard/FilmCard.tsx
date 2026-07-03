import { Button, Card, CardActions, CardContent, CardMedia, Grid, Typography } from "@mui/material"

type Props = {
    film: Film
    selectFilm: (id: number) => void;
}

export default function FilmCard({film, selectFilm}: Props) {
  return (
    <Card sx={{
        backgroundImage: 'linear-gradient(145deg, #1e1e24, #121215)', 
        color: '#ffffff',
        borderRadius: 2,
        border: '1px solid #dd0d86',
        boxShadow: '0 0 30px rgba(114, 7, 69, 0.6)'
        }}>
        <Grid container sx={{columnGap: 3}}>
            <Grid size={5}>
                <CardContent>
                    <Typography variant="h5">{film.title}</Typography>
                    <Typography sx={{mb: 1}}>{film.date}</Typography>
                    <Typography variant="subtitle1">Category: {film.category}</Typography>
                </CardContent>
            </Grid>
        <Grid size={5} sx={{pl: 32}}>
            <CardMedia
            component='img'
            height='120'
            src={`/images/filmImages/${film.id}.jpg`}   
            sx={{objectFit: 'cover', boxShadow: '0 0 15px rgba(199, 180, 191, 0.6)', width: 80}}

            />
          </Grid>
        </Grid>
        <CardActions sx={{display: 'flex', justifyContent: 'space-between', pb: 2}}>
            <Button 
            onClick={() => {selectFilm(film.id); window.scrollTo({top: 0, behavior: 'smooth'})}} 
            size="medium" variant="contained" sx={{bgcolor: '#dd0d86'}}>Reviews</Button>
            <Button size="medium" variant="contained" sx={{bgcolor: '#dd0d86'}}>Buy Tickets</Button>
        </CardActions>
    </Card>
  )
}

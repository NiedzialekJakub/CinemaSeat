import { Box, Button, Card, CardContent, CardMedia, Grid, Typography } from "@mui/material"

type Props ={
    film: Film
    cancelSelectedFilm: () => void;
}

export default function FilmDetail({film, cancelSelectedFilm}: Props) {
  return (
      <Card sx={{
        borderRadius: 3, 
        backgroundImage: 'linear-gradient(145deg, #1e1e24, #121215)', 
        color: '#ffffff',
        border: '1px solid #dd0d86',
        boxShadow: '0 0 60px rgba(114, 7, 69, 0.6)',
        width: 900,
        height: 680,
        p: 3,
        }}>
          <Grid container sx={{columnGap: 6}}>

            <Grid size={5}>
              <CardMedia
              component='img'
              height='600'
              src={`/images/filmImages/${film.id}.jpg`}   
              sx={{objectFit: 'cover', boxShadow: '0 0 30px rgba(199, 180, 191, 0.6)', width: 400}}

              />
            </Grid>

            <Grid size={6} sx={{paddingTop: 2, pl: 10}}>
              <CardContent>
                <Typography variant="h3">{film.title}</Typography>
                <Typography variant="h5">Category: {film.category}</Typography>
                <Typography variant="h6" sx={{fontWeight: 'light'}}>{film.date}</Typography>
                <Typography variant="h6">Screening Room: {film.screeningRoom}</Typography>
                <Typography variant="h6" sx={{fontWeight: 'light'}}>{film.description}</Typography>
              </CardContent>
            </Grid>
                <Box  sx={{paddingLeft: 19, pl: 60, display: 'flex', gap: 6}}>
                  <Button 
                    size="large"
                    onClick={cancelSelectedFilm} variant="contained" 
                    sx={{bgcolor: '#dd0d86'}}>
                    Cancel
                  </Button>
                  <Button size="large" sx={{bgcolor: '#dd0d86', color: 'white'}}>
                    Buy Tickets
                  </Button>
                </Box>
          </Grid>
      </Card>
  )
}

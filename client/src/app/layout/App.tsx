import { Box, Container, CssBaseline} from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react"
import NavBar from "./NabBar";
import FilmDashboard from "../../features/films/dashboard/FilmDashboard";


function App() {
  const [films, setFilms] = useState<Film[]>([]);
  const [selectedFilm, setSelectedFilm] = useState<Film | undefined>(undefined);

  useEffect(() => {
      axios.get<Film[]>('https://localhost:5001/api/films')
        .then(response => setFilms(response.data))
  }, [])

  const handleSelectFilm = (id: number) => {
    setSelectedFilm(films.find(x => x.id === id));
  }

  const handleCancelSelectFilm = () => {
    setSelectedFilm(undefined);
  }

  return (
    <Box sx={{bgcolor: '#121212'}}>
    <CssBaseline />
      <NavBar />
      <Container maxWidth='xl' sx={{mt: 3}}>
        <FilmDashboard 
        films={films}
        selectFilm={handleSelectFilm}
        cancelSelectFilm={handleCancelSelectFilm}
        selectedFilm={selectedFilm}
        />
      </Container>

    </Box>
  )
}

export default App

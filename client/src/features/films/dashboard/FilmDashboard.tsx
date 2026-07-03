import { Grid, Typography} from "@mui/material";
import FilmList from "./FilmList";
import FilmDetail from "../details/FilmDetail";
import {useState } from "react";
import { useFilms } from "../../../lib/hooks/useFilms";


export default function FilmDashboard() {
    const [selectedFilm, setSelectedFilm] = useState<Film | undefined>(undefined);
    const {films, isPending} = useFilms();

      const handleSelectFilm = (id: number) => {
        setSelectedFilm(films!.find(x => x.id === id));
      }
    
      const handleCancelSelectFilm = () => {
        setSelectedFilm(undefined);
      }

  return (
    <Grid container sx={{columnGap: 10}}>
        <Grid size={5}>
            {!films || isPending ? (
                <Typography variant="h2" sx={{color: 'white'}}>Loading...</Typography>
            ) : (
                <FilmList 
                films={films} 
                selectFilm={handleSelectFilm}
                />
            )}
        </Grid>
        <Grid size={5}>
            {selectedFilm && <FilmDetail film={selectedFilm} cancelSelectedFilm={handleCancelSelectFilm} />}
        </Grid>
    </Grid>
  )
}

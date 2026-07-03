import { Grid} from "@mui/material";
import FilmList from "./FilmList";
import FilmDetail from "../details/FilmDetail";

type Props = {
    films: Film[]
    selectFilm: (id: number) => void;
    cancelSelectFilm: () => void;
    selectedFilm?: Film;
}

export default function FilmDashboard({films, selectFilm, cancelSelectFilm, selectedFilm}: Props) {
  return (
    <Grid container sx={{columnGap: 10}}>
        <Grid size={5}>
            <FilmList 
            films={films} 
            selectFilm={selectFilm}
            />
        </Grid>
        <Grid size={5}>
            {selectedFilm && <FilmDetail film={selectedFilm} cancelSelectedFilm={cancelSelectFilm} />}
        </Grid>
    </Grid>
  )
}

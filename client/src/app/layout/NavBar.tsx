import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import { Group} from '@mui/icons-material'
import { Container } from '@mui/material';
import { Link } from 'react-router';

export default function NavBar() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" sx={{backgroundImage: 'linear-gradient(135deg, #0f0f12 0%, #15151a 50%, #1a1a24 100%)'}}>
        <Container maxWidth='xl'>
            <Toolbar sx={{display: 'flex', justifyContent: 'space-between'}}>
                <Box sx={{display: 'flex', alignItems: 'center', gap: 2}}>
                    <Group fontSize="large"/>
                    <Button
                        component={Link} to=''
                        sx={{fontSize: '1.2rem', color: 'white', fontWeight: 'bold'}}>
                        Cinema
                    </Button>
                </Box>
                <Box sx={{display: 'flex', gap: 2}}>
                    <Button component={Link} to='/films'
                        sx={{fontSize: '1.2rem', color: 'white', fontWeight: 'bold'}}>
                        Showtimes
                    </Button>
                    <Button sx={{fontSize: '1.2rem', color: 'white', fontWeight: 'bold'}}>
                        Profile
                    </Button>
                </Box>
            </Toolbar>
        </Container>
      </AppBar>
    </Box>
  );
}

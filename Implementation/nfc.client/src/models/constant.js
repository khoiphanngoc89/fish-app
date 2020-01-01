import { NEXT_PAGE, PREVIOUS_PAGE, PAGE, CURRENT_PAGE, PRE_PAGE_ICO, NEXT_PAGE_ICO } from '@/utils/constants/shared.constant'

const initConstant = () => {
    return {
        table: {
            nextPage: NEXT_PAGE,
            previousPage: PREVIOUS_PAGE,
            page: PAGE,
            currentPage: CURRENT_PAGE,
            prePageIco: PRE_PAGE_ICO,
            nextPageIco: NEXT_PAGE_ICO
        }
    }
}

export const constant = {
    ...initConstant()
}